using UnityEngine;

namespace BattleGame.Charactor
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(CapsuleCollider))]
    [RequireComponent(typeof(Rigidbody))]
    public class Player : MonoBehaviour
    {
		#region 変数
		public static float hp;

        public float animSpeed = 1.5f;              // アニメーション再生速度設定
        public float lookSmoother = 3.0f;           // a smoothing setting for camera motion
        public bool useCurves = true;               // Mecanimでカーブ調整を使うか設定する
                                                    // このスイッチが入っていないとカーブは使われない
        public float useCurvesHeight = 0.5f;        // カーブ補正の有効高さ（地面をすり抜けやすい時には大きくする）

        // 以下キャラクターコントローラ用パラメタ
        // 前進速度
        public float forwardSpeed = 7.0f;
        // 旋回速度
        public float rotateSpeed = 2.0f;
        // ジャンプ威力
        public float jumpPower = 3.0f;
        // キャラクターコントローラ（カプセルコライダ）の参照
        private CapsuleCollider col;
        private Rigidbody rb;
        // キャラクターコントローラ（カプセルコライダ）の移動量
        private Vector3 velocity;
        // CapsuleColliderで設定されているコライダのHeiht、Centerの初期値を収める変数
        private float orgColHight;
        private Vector3 orgVectColCenter;
        private Animator anim;                          // キャラにアタッチされるアニメーターへの参照
        private AnimatorStateInfo currentBaseState;         // base layerで使われる、アニメーターの現在の状態の参照
		private AnimatorStateInfo attackBaseState;

		float h;
		float v;

		// アニメーター各ステートへの参照
		static int idleState = Animator.StringToHash("Base Layer.Idle");
        static int locoState = Animator.StringToHash("Base Layer.Locomotion");
        static int backState = Animator.StringToHash("Base Layer.WalkBack");
        static int jumpState = Animator.StringToHash("Base Layer.Jump");
        static int restState = Animator.StringToHash("Base Layer.Rest");
		static int attackState = Animator.StringToHash("Attack.Idle");
		#endregion

		#region monofunction
		void Start()
		{
			Init();
		}

        private void Update()
        {
			if (GameManager.isTimeStop != true) return;
            
			CharactorJump();
        }

        void FixedUpdate()
		{
			if (GameManager.isTimeStop != true) return;

			OnMoveFunction();
		}

        private void OnCollisionStay(Collision collision)
        {
            if (collision.gameObject.tag == "Enemy")
            {
				Debug.Log("Enemy");
				hp -= 1f;
            }
        }

        #endregion

        #region function
        /// <summary>
        /// 初期化
        /// </summary>
        private void Init()
        {
			hp = 100;

			// Animatorコンポーネントを取得する
			anim = GetComponent<Animator>();
			// CapsuleColliderコンポーネントを取得する（カプセル型コリジョン）
			col = GetComponent<CapsuleCollider>();
			rb = GetComponent<Rigidbody>();
			// CapsuleColliderコンポーネントのHeight、Centerの初期値を保存する
			orgColHight = col.height;
			orgVectColCenter = col.center;
		}

		void InputFunction()
        {
			h = Input.GetAxis("Horizontal");              // 入力デバイスの水平軸をhで定義
			v = Input.GetAxis("Vertical");                // 入力デバイスの垂直軸をvで定義
			float ho = Mathf.Abs(h);
			anim.SetFloat("Speed", v + ho);                          // Animator側で設定している"Speed"パラメタにvを渡す
			anim.SetFloat("Direction", h / 2);                      // Animator側で設定している"Direction"パラメタにhを渡す
			anim.speed = animSpeed;                             // Animatorのモーション再生速度に animSpeedを設定する
			currentBaseState = anim.GetCurrentAnimatorStateInfo(0); // 参照用のステート変数にBase Layer (0)の現在のステートを設定する
			rb.useGravity = true;//ジャンプ中に重力を切るので、それ以外は重力の影響を受けるようにする

		}

		void CharactorJump()
        {
			if (Input.GetKeyDown(KeyCode.Space))
			{
				// スペースキーを入力したら
				//アニメーションのステートがLocomotionの最中のみジャンプできる
				if (currentBaseState.fullPathHash == locoState ||
					currentBaseState.fullPathHash == idleState ||
					currentBaseState.fullPathHash == backState)
				{
					//ステート遷移中でなかったらジャンプできる
					if (!anim.IsInTransition(0))
					{
						rb.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
						anim.SetBool("Jump", true);     // Animatorにジャンプに切り替えるフラグを送る
					}
				}
			}
		}

		void CharactorMove()
        {
			Vector3 cameraPos = new Vector3(Camera.main.transform.position.x, 0, Camera.main.transform.position.z);

			Vector3 cameraForward = this.transform.position - cameraPos;

			cameraForward = cameraForward.normalized;

			Vector3 velocity = cameraForward * v + Camera.main.transform.right * h;

			velocity *= forwardSpeed;

			// 上下のキー入力でキャラクターを移動させる
			transform.position += velocity * Time.fixedDeltaTime;

			// 左右のキー入力でキャラクタをY軸で旋回させる
			transform.Rotate(0, h * rotateSpeed, 0);
            if (velocity != Vector3.zero)
            {
				// 移動方向に向かせる。
				transform.rotation = Quaternion.LookRotation(velocity);
			}
			// 以下、Animatorの各ステート中での処理
			// Locomotion中
			// 現在のベースレイヤーがlocoStateの時
			if (currentBaseState.fullPathHash == locoState)
			{
				//カーブでコライダ調整をしている時は、念のためにリセットする
				if (useCurves)
				{
					resetCollider();
				}
			}
			// JUMP中の処理
			// 現在のベースレイヤーがjumpStateの時
			else if (currentBaseState.fullPathHash == jumpState)
			{
				if (!anim.IsInTransition(0))
				{

					// 以下、カーブ調整をする場合の処理
					if (useCurves)
					{
						// 以下JUMP00アニメーションについているカーブJumpHeightとGravityControl
						// JumpHeight:JUMP00でのジャンプの高さ（0〜1）
						// GravityControl:1⇒ジャンプ中（重力無効）、0⇒重力有効
						float jumpHeight = anim.GetFloat("JumpHeight");
						float gravityControl = anim.GetFloat("GravityControl");
						if (gravityControl > 0)
							rb.useGravity = false;  //ジャンプ中の重力の影響を切る

						// レイキャストをキャラクターのセンターから落とす
						Ray ray = new Ray(transform.position + Vector3.up, -Vector3.up);
						RaycastHit hitInfo = new RaycastHit();
						// 高さが useCurvesHeight 以上ある時のみ、コライダーの高さと中心をJUMP00アニメーションについているカーブで調整する
						if (Physics.Raycast(ray, out hitInfo))
						{
							if (hitInfo.distance > useCurvesHeight)
							{
								col.height = orgColHight - jumpHeight;          // 調整されたコライダーの高さ
								float adjCenterY = orgVectColCenter.y + jumpHeight;
								col.center = new Vector3(0, adjCenterY, 0); // 調整されたコライダーのセンター
							}
							else
							{
								// 閾値よりも低い時には初期値に戻す（念のため）					
								resetCollider();
							}
						}
					}
					// Jump bool値をリセットする（ループしないようにする）				
					anim.SetBool("Jump", false);
				}
			}
			// IDLE中の処理
			// 現在のベースレイヤーがidleStateの時
			else if (currentBaseState.fullPathHash == idleState)
			{
				anim.SetInteger("Attack", 0);
				if (Input.GetMouseButtonDown(0))
				{
					anim.SetInteger("Attack", 1);
					return;
				}

				//カーブでコライダ調整をしている時は、念のためにリセットする
				if (useCurves)
				{
					resetCollider();
				}
				// スペースキーを入力したらRest状態になる
				if (Input.GetKeyDown(KeyCode.L))
				{
					anim.SetBool("Rest", true);
				}
			}
			// REST中の処理
			// 現在のベースレイヤーがrestStateの時
			else if (currentBaseState.fullPathHash == restState)
			{
				//cameraObject.SendMessage("setCameraPositionFrontView");		// カメラを正面に切り替える
				// ステートが遷移中でない場合、Rest bool値をリセットする（ループしないようにする）
				if (!anim.IsInTransition(0))
				{
					anim.SetBool("Rest", false);
				}
			}
		}

		void OnMoveFunction()
        {
			InputFunction();

			CharactorMove();
		}

		void resetCollider()
		{
			// コンポーネントのHeight、Centerの初期値を戻す
			col.height = orgColHight;
			col.center = orgVectColCenter;
		}
        #endregion
    }
}
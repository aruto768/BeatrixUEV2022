using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;


[ExecuteAlways]
public class PanelGrids : MonoBehaviour
    {
        [SerializeField]
        protected float _distanceToChild = 2f;

        [SerializeField]
        protected float _childScale = 1f;

        [SerializeField]
        protected bool _distanceScaleMatch = true;

        [SerializeField]
        [Range(0f, 60f)]
        [Tooltip("Angle in Degrees")]
        protected int _childHeight = 8;

        private bool _isFirstFrame = true;
        private string _renderPipeline;

        protected void Awake()
        {
            string rpAsset = "";
            if (GraphicsSettings.renderPipelineAsset != null)
                rpAsset = GraphicsSettings.renderPipelineAsset.GetType().Name;

            if (rpAsset.Equals("HDRenderPipelineAsset"))
            {
                _renderPipeline = "HDRP";
            }
            else if (rpAsset.Equals("UniversalRenderPipelineAsset"))
            {
                _renderPipeline = "URP";
            }
            else
            {
                _renderPipeline = "Builtin";
                StartCoroutine(CameraReady());
            }
        }

        private void OnEnable()
        {
            if (_renderPipeline.Equals("HDRP") || _renderPipeline.Equals("URP"))
            {
                RenderPipelineManager.beginCameraRendering += SetUpCamera;
            }
        }

        private void OnDisable()
        {
            if (_renderPipeline.Equals("HDRP") || _renderPipeline.Equals("URP"))
            {
                RenderPipelineManager.beginCameraRendering -= SetUpCamera;
            }
        }

        void SetUpCamera(ScriptableRenderContext context, Camera camera)
        {
            if (_isFirstFrame)
            {
                SetUITransform();
                _isFirstFrame = false;
            }
        }

        private void OnValidate()
        {
            if (_distanceScaleMatch)
            {
                _childScale = _distanceToChild;
            }
        }

        IEnumerator CameraReady()
        {
            while (Camera.current == null)
            {
                yield return new WaitForSeconds(.05f);
            }

#if UNITY_EDITOR
            while (Time.time < 1.5f)
            {
                yield return new WaitForSeconds(.05f);
            }
#endif
            SetUITransform();
        }

        protected virtual void Update()
        {
#if UNITY_EDITOR
            if (!Application.isPlaying && Camera.main != null)
            {
                SetUITransform();
            }
#endif
        }

        protected virtual void SetUITransform()
        {
            if (Camera.main != null)
            {
                float uiHeight = Camera.main.transform.position.y - _distanceToChild * Mathf.Tan(_childHeight * Mathf.Deg2Rad);
                SetUITransform(uiHeight);
            }
            else
            {
                Debug.LogWarning("No Main Camera found");
            }
        }

        protected virtual void SetUITransform(float uiHeight)
        {
            SetPosition(uiHeight);
            SetScale();
            SetRotation(uiHeight);
        }

        protected void SetPosition(float uiHeight)
        {
            Transform camera = Camera.main.transform;
            Vector3 forward = new Vector3(camera.forward.x, 0, camera.forward.z);
            forward.Normalize();
            Vector3 position = camera.position + forward * _distanceToChild;

            this.transform.position = new Vector3(position.x, uiHeight, position.z);
        }

        protected void SetScale()
        {
            float scale;

            if (_distanceScaleMatch)
            {
                scale = _distanceToChild;
            }
            else
            {
                scale = _childScale;
            }

            foreach (Canvas canvas in GetComponentsInChildren<Canvas>())
            {
                canvas.transform.localScale = new Vector3(scale, scale, scale);
            }
        }

        protected void SetRotation(float uiHeight)
        {
            Vector3 target = Camera.main.transform.position;
            target.y = transform.position.y;
            Vector3 notLookAt = transform.position + new Vector3(0, uiHeight, 0) - (target - transform.position + new Vector3(0, uiHeight, 0));
            this.transform.LookAt(notLookAt);
        }
    }

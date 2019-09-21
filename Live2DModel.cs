using UnityEngine;
using System;
using System.Collections;
using live2d;
using live2d.framework;

namespace DlibFaceLandmarkDetectorWithLive2DSample
{
    [ExecuteInEditMode]
    public class Live2DModel : MonoBehaviour
    {
        public TextAsset mocFile;
        public TextAsset physicsFile;
        public TextAsset poseFile;
        public Texture2D[] textureFiles;

        public Vector3 PARAM_ANGLE;
        [Range(-1.0f, 2.0f)]
        public float PARAM_EYE_L_OPEN;
        [Range(-1.0f, 2.0f)]
        public float PARAM_EYE_R_OPEN;

        [Range(-1.0f, 1.0f)]
        public float PARAM_EYE_BALL_X;
        [Range(-1.0f, 1.0f)]
        public float PARAM_EYE_BALL_Y;

        [Range(-1.0f, 1.0f)]
        public float PARAM_BROW_L_Y;
        [Range(-1.0f, 1.0f)]
        public float PARAM_BROW_R_Y;

        [Range(0.0f, 2.0f)]
        public float PARAM_MOUTH_OPEN_Y;

        [Range(-1.0f, 1.0f)]
        public float PARAM_MOUTH_SIZE;


        private Live2DModelUnity live2DModel;
        private L2DPhysics physics;
        private L2DPose pose;
        private Matrix4x4 live2DCanvasPos;

        void Start()
        {
            Live2D.init();

            load();
        }


        void load()
        {
            live2DModel = Live2DModelUnity.loadModel(mocFile.bytes);

            for (int i = 0; i < textureFiles.Length; i++)
            {
                live2DModel.setTexture(i, textureFiles[i]);
            }

            float modelWidth = live2DModel.getCanvasWidth();
            live2DCanvasPos = Matrix4x4.Ortho(0, modelWidth, modelWidth, 0, -50.0f, 50.0f);

            if (physicsFile != null) physics = L2DPhysics.load(physicsFile.bytes);

            pose = L2DPose.load(poseFile.bytes);
        }


        void Update()
        {
            if (live2DModel == null) load();
            live2DModel.setMatrix(transform.localToWorldMatrix * live2DCanvasPos);
            if (!Application.isPlaying)
            {
                live2DModel.update();
                return;
            }

            double timeSec = UtSystem.getUserTimeMSec() / 1000.0;
            double t = timeSec * 2 * Math.PI;
            live2DModel.setParamFloat("PARAM_BREATH", (float)(0.5f + 0.5f * Math.Sin(t / 3.0)));

            //
            live2DModel.setParamFloat("PARAM_ANGLE_X", PARAM_ANGLE.x);
            live2DModel.setParamFloat("PARAM_ANGLE_Y", PARAM_ANGLE.y);
            live2DModel.setParamFloat("PARAM_ANGLE_Z", PARAM_ANGLE.z);
            live2DModel.setParamFloat("PARAM_EYE_L_OPEN", PARAM_EYE_L_OPEN);
            live2DModel.setParamFloat("PARAM_EYE_R_OPEN", PARAM_EYE_R_OPEN);
            live2DModel.setParamFloat("PARAM_EYE_BALL_X", PARAM_EYE_BALL_X);
            live2DModel.setParamFloat("PARAM_EYE_BALL_Y", PARAM_EYE_BALL_Y);
            live2DModel.setParamFloat("PARAM_BROW_L_Y", PARAM_BROW_L_Y);
            live2DModel.setParamFloat("PARAM_BROW_R_Y", PARAM_BROW_R_Y);
            live2DModel.setParamFloat("PARAM_MOUTH_OPEN_Y", PARAM_MOUTH_OPEN_Y);
            live2DModel.setParamFloat("PARAM_MOUTH_SIZE", PARAM_MOUTH_SIZE);

            live2DModel.setParamFloat("PARAM_MOUTH_FORM", 0.0f);
            //

            if (physics != null) physics.updateParam(live2DModel);

            if (pose != null) pose.updateParam(live2DModel);


            live2DModel.update();
        }


        void OnRenderObject()
        {
            if (live2DModel == null) load();
            if (live2DModel.getRenderMode() == Live2D.L2D_RENDER_DRAW_MESH_NOW) live2DModel.draw();
        }
    }
}
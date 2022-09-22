using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;


namespace SG
{

    public class NemesisAgent : Agent
    {
        public float positiveReward = 1;
        public float negativeReward = -1;
        public float trainingArea = 4;

        [SerializeField]
        private Rigidbody rb;
        [SerializeField]
        private Transform targetTransform;


        private NemesisController nemesisController;

        public override void Initialize()
        {
            nemesisController = GetComponent<NemesisController>();
        }

        public override void OnEpisodeBegin()
        {
            rb.velocity = Vector3.zero;
            transform.rotation = Quaternion.Euler(Vector3.up * Random.Range(0f, 360f));

            transform.localPosition = new Vector3(Random.Range(trainingArea, -trainingArea), 0, Random.Range(-trainingArea, trainingArea));
            targetTransform.localPosition = new Vector3(Random.Range(trainingArea, -trainingArea), 0, Random.Range(-trainingArea, trainingArea));
        }

        public override void OnActionReceived(ActionBuffers actions)
        {
            float moveInput = actions.DiscreteActions[0] <= 1 ? actions.DiscreteActions[0] : 0;
            float rotateInput = actions.DiscreteActions[1] <= 1 ? actions.DiscreteActions[1] : -1;
            bool attackInput = actions.DiscreteActions[2] > 0;


            nemesisController.moveInput = moveInput;
            nemesisController.rotateInput = rotateInput;
            nemesisController.attackInput = attackInput;

            AddReward(-1f / MaxStep);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Wall>(out Wall Wall))
            {
                AddReward(negativeReward);
                EndEpisode();
            }
        }

        public void AttackSuccess()
        {
            AddReward(positiveReward);
            EndEpisode();
        }
    }
}
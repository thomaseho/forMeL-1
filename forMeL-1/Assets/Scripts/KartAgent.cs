using System;
using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;

public class KartAgent : Agent
{
   public CheckpointManager checkpointManager;
   private KartController _kartController;
   
   public override void Initialize()
   {
      _kartController = GetComponent<KartController>();
   }
   
   public override void OnEpisodeBegin()
   {
      checkpointManager.ResetCheckpoints();
      _kartController.Respawn();
   }

   #region Behaviour

      public override void CollectObservations(VectorSensor sensor)
      {
         Vector3 diff = checkpointManager.nextCheckPointToReach.transform.position - transform.position;
         sensor.AddObservation(diff / 20);
         AddReward(-0.001f);
      }

      public override void OnActionReceived(ActionBuffers actions)
      {
         var input = actions.ContinuousActions;
         _kartController.ApplyAcceleration(input[1]);
         _kartController.Steer(input[0]);
      }
      
      public override void Heuristic(in ActionBuffers actionsOut)
      {
         var action = actionsOut.ContinuousActions;

         action[0] = Input.GetAxis("Horizontal");
         
         if (Input.GetKey(KeyCode.W))
         {
            action[1] = 1f;
         }
         else if (Input.GetKey(KeyCode.S))
         {
            action[1] = -1f;
         }
         else
         {
            action[1] = 0f;
         }
      }
      
   #endregion
}

/*******************************************
 * Created by Pavel Korolev
 * Last Modified 19.04.2022
 *******************************************/

using System.Collections.Generic;
using UnityEngine;

namespace AI.BehaviorTree.Nodes
{
    public abstract class CompositeNode : Node
    {
        public AnimationCurve Curve; 
        [HideInInspector] public List<Node> ChildNodes = new List<Node>();
    }
  
}
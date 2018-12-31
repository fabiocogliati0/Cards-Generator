using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards_Generator
{
    public abstract class FSMState
    {

        public static FSMState CreateFSMState(Name name, string Class)
        {
            FSMState createdState = null;

            try
            {
                Type FSMType = Type.GetType(Class);

                if (FSMType == null)
                {
                    throw new Exception(Class + " type not found during creation of fsm state with name : " + name);
                }

                createdState = Activator.CreateInstance(FSMType) as FSMState;

                if (createdState != null)
                {
                    createdState.Name = name;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return createdState;
        }


        public abstract void OnEnter();

        public abstract void OnExit();

        //public abstract void OnUpdate();

        public abstract void OnAction(Name Action, Name Param);



        public Name Name
        {
            get; private set;
        }


        protected void TriggerTranstion(Name Transition)
        {
            CurrentFSM.TriggerTransition(Transition);
        }

        public void FireAction(Name Action, Name Param)
        {
            OnAction(Action, Param);
        }




        public FSM CurrentFSM;

        
    }
}

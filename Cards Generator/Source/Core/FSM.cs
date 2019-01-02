using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace Cards_Generator
{


    public class FSMStateDeclaration
    {
        // Name of the FSM state
        public Name Name;

        // Class of the FSM state
        public string Class;

        // Dictionary transition name to destination state name
        public Dictionary<Name, Name> Transitions;
    }

    public class FSM
    {    

        // Name of the FSM read from JSON
        public Name Name;

        // Name of the enter state of the FSM read from JSON
        public Name EnterStateName;

        // List of states read from JSON
        public List<FSMStateDeclaration> StatesDeclarations;



        public static FSM CreateFSM(string JSONFilePath)
        {
            FSM createdFSM;

            try
            {
                using (StreamReader reader = new StreamReader(JSONFilePath))
                {
                    string json = reader.ReadToEnd();
                    createdFSM = JsonConvert.DeserializeObject<FSM>(json);
                    createdFSM._states = new List<FSMState>(createdFSM.StatesDeclarations.Count);

                    foreach (FSMStateDeclaration stateDeclaration in createdFSM.StatesDeclarations)
                    {
                        FSMState createdState = FSMState.CreateFSMState(stateDeclaration.Name, stateDeclaration.Class);
                        createdState.CurrentFSM = createdFSM;
                        createdFSM._states.Add(createdState);
                    }

                }
            }
            catch (Exception e)
            {
                createdFSM = null;
                Console.WriteLine(e.Message);
            }

            return createdFSM;
        }


        private FSM()
        {
        }

        public void Start()
        {
            SetCurrentState(EnterStateName);
            _currentState.OnEnter();
        }

        public void TriggerTransition(Name Transition)
        {
            if (_currentStateDeclaration.Transitions != null)
            {
                if (_currentStateDeclaration.Transitions.ContainsKey(Transition))
                {
                    _currentState.OnExit();
                    Name destinationState = _currentStateDeclaration.Transitions[Transition];
                    SetCurrentState(destinationState);
                    _currentState.OnEnter();
                }
            }
        }


        private void SetCurrentState(Name stateName)
        {
            _currentState = _states.Find(x => x.Name == stateName);
            _currentStateDeclaration = StatesDeclarations.Find(x => x.Name == stateName);
        }


        private List<FSMState> _states;

        private FSMState _currentState;

        private FSMStateDeclaration _currentStateDeclaration;


    }


}

using System;
using System.Security.Cryptography.X509Certificates;
using EventHandlers;

namespace EventHandlers {
    class ChangeEventArgs : EventArgs {
        private string title;

        public string Title {
            get { return title; }
        }

        private int change;

        public int Change {
            get { return change; }
        }

        public ChangeEventArgs(string str, int change) {
            this.change = change;
            this.title = str;
        }
    }

    class GenerateEvent {
        // Generator
        // Delegate Type creation
        public delegate void ChangeEventHandler(object source, ChangeEventArgs e);
        // Delegate instance creation
        public event ChangeEventHandler onChangeHandler; // !⚡️

        public void UpdateEvent(string str, int change) {
            if (change == 0)
                return;

            ChangeEventArgs changer = new ChangeEventArgs(str, change);

            if (onChangeHandler != null)
                onChangeHandler(this, changer);
        }
    }

    class ReceiveEvent {
        // Receiver
        void onRecChange(object source, ChangeEventArgs changer) { // обработчик
            int change = changer.Change;
            Console.WriteLine("Weight '{0}' was {1} by {2} tonns", changer.Title,
                change > 0 ? "increased" : "decreased", Math.Abs(changer.Change));
        }

        GenerateEvent generateEvent;

        public ReceiveEvent(GenerateEvent generateEvent) {
            this.generateEvent = generateEvent;
            
            generateEvent.onChangeHandler += new GenerateEvent.ChangeEventHandler(onRecChange); // subscription !
        }
    }

    class Program {
        static void Main(string[] args) {

            GenerateEvent generateEvent = new GenerateEvent();
            ReceiveEvent inventoryWatch = new ReceiveEvent(generateEvent);

            generateEvent.UpdateEvent("Trucks", -2);
            generateEvent.UpdateEvent("Road trains", 4);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


namespace dataReceivers {

    public enum DataReceiverOperationType { StaticType, ContinuousType, DiscreteType }

    public class DataReceiversMethods
    {

        public static List<System.Type> getReceiversList()
        {
            List<System.Type> list = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.Namespace == "dataReceivers").ToList();
            list.Remove(typeof(DataReceiversMethods));
            list.Remove(typeof(DataReceiverOperationType));
            list.Remove(typeof(IDataReceivers));
            return list;
        }
   
    }

    public interface IDataReceivers
    {

        // Name of the data receiver
        String ReceiverName { get; } 
        
        // Type of operation of the data receiver 
        DataReceiverOperationType ReceiverType { get; }

        // Type of data returned by the receiver
        System.Type DataType { get; }

        // To get the data collected by the receiver
        object getData();
    }

    public class DataRandomDiscreteGenerator : IDataReceivers
    {
        public String ReceiverName
        {
            get
            {
                return "Discrete Random Generator";
            }
        }

        public DataReceiverOperationType ReceiverType
        {
            get
            {
                return DataReceiverOperationType.DiscreteType;
            }
        }

        public System.Type DataType
        {
            get
            {
                return typeof(float);
            }
        }

        // RECEIVER IN-PARAMETERS
        private float min_value;
        private float max_value;

        // RECEIVER INPUTS
        Dictionary<string, object>[] inputList;

        DataRandomDiscreteGenerator()
        {
            setDefaultValues();
            initializeDictionary();
        }

        DataRandomDiscreteGenerator(float min_value, float max_value)
        {
            setMinValue(min_value);
            setMaxValue(max_value);
            initializeDictionary();
        }

        void initializeDictionary()
        {

            inputList = new[] {

                new Dictionary<string, object>(){
                    { "input_id", "min_value_input" },
                    { "input_label", "Minimum Value" },
                    { "input_type" , typeof(float) },
                    { "output_type", typeof(void) },
                    { "input_call_function", new Action<float>(setMinValue) }
                },

                new Dictionary<string, object>()
                {
                    { "input_id", "max_value_input" },
                    { "input_label", "Maximum Value" },
                    { "input_type" , typeof(float) },
                    { "output_type", typeof(void) },
                    { "input_call_function", new Action<float>(setMaxValue) }
                },

                new Dictionary<string, object>()
                {
                    { "input_id", "default_parameters_input" },
                    { "input_label", "Default" },
                    { "input_type" , typeof(void) },
                    { "output_type", typeof(void) },
                    { "input_call_function", new Action(setDefaultValues) }
                },

                new Dictionary<string, object>()
                {
                    { "input_id", "test_getData" },
                    { "input_label", "Test" },
                    { "input_type" , typeof(void)  },
                    { "return_type", typeof(object) },
                    { "input_call_function", new Func<object>(getData) }
                }

            };

        }

        public object getData()
        {
            Random random = new Random();
            return random.NextDouble() * (min_value - max_value) + min_value;
        }

        public void setDefaultValues()
        {
            min_value = 0.0f;
            max_value = 1.0f;
        }

        public void setMinValue(float value)
        {
            min_value = value;
        }

        public void setMaxValue(float value)
        {
            max_value = value;
        }
    }

    public class DataRandomStaticGenerator : IDataReceivers
    {

        // RECEIVER PROPERTIES
        public String ReceiverName
        {
            get
            {
                return "Static Random Generator";
            }
        }

        public DataReceiverOperationType ReceiverType
        {
            get
            {
                return DataReceiverOperationType.StaticType;
            }
        }

        public System.Type DataType
        {
            get
            {
                return typeof(float);
            }
        }

        // RECEIVER IN-PARAMETERS
        private float min_value;
        private float max_value;

        // RECEIVER INPUTS
        Dictionary<string, object>[] inputList;

        DataRandomStaticGenerator()
        {
            setDefaultValues();
            initializeDictionary();
        }

        DataRandomStaticGenerator(float min_value, float max_value)
        {
            setMinValue(min_value);
            setMaxValue(max_value);
            initializeDictionary();
        }

        void initializeDictionary()
        {

            inputList = new[] {

                new Dictionary<string, object>(){
                    { "input_id", "min_value_input" },
                    { "input_label", "Minimum Value" },
                    { "input_type" , typeof(float) },
                    { "output_type", typeof(void) },
                    { "input_call_function", new Action<float>(setMinValue) }
                },

                new Dictionary<string, object>()
                {
                    { "input_id", "max_value_input" },
                    { "input_label", "Maximum Value" },
                    { "input_type" , typeof(float) },
                    { "output_type", typeof(void) },
                    { "input_call_function", new Action<float>(setMaxValue) }
                },

                new Dictionary<string, object>()
                {
                    { "input_id", "default_parameters_input" },
                    { "input_label", "Default" },
                    { "input_type" , typeof(void) },
                    { "output_type", typeof(void) },
                    { "input_call_function", new Action(setDefaultValues) }
                },

                new Dictionary<string, object>()
                {
                    { "input_id", "test_getData" },
                    { "input_label", "Test" },
                    { "input_type" , typeof(void)  },
                    { "return_type", typeof(object) },
                    { "input_call_function", new Func<object>(getData) }
                }

            };
    
        }

        public object getData()
        {
            Random random = new Random();
            return random.NextDouble() * (min_value - max_value) + min_value;
        }

        public void setDefaultValues()
        {
            min_value = 0.0f;
            max_value = 1.0f;
        }

        public void setMinValue(float value)
        {
            min_value = value;
        }

        public void setMaxValue(float value)
        {
            max_value = value;
        }

    }

}
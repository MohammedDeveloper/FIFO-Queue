using System;
// No additional "using" statements may be added.
// Adding references as "System.Collections.Hashtable myHashtable = ..." are also disallowed.
// No use of Array.sort() or Array.resize(), or any built-in or API methods that provide this functionality.
namespace PriorityQueue
{
    class Program
    {

        /// A PriorityQueue is a FIFO queue/buffer that supports the additional idea of "priority".
        /// Items of highest priority are returned first.
        /// Items of same priority are returned FIFO.
        public interface PriorityQueue
        {
            /// Add a task to the Queue.
            /// priority will always be provided as a non-negative integer (zero is valid)
            /// zero (0) is the lowest priority, max priority is only limited by the integer type.
            void AddTask(String taskDescription, int priority);

            /// Return the "next" task based on the rules above and remove it from the queue.
            /// If the Queue is empty, return null.
            String NextTask();
        }

        /************************************************************************************
        *     Implement your version of the PriorityQueue interface below as "myQueue".     * 
        *************************************************************************************/
        /// Note:  Inner classes are allowed.
        /// Note:  Queues should be able to hold an unlimited number of elements (consistent with available memory).
        /// Note:  Concentrate on creating a clean, easy to follow solution, using standard langauge features and OO design.

        /// <summary>
        /// Represents the class for Queue Item
        /// </summary>
        public class Task
        {
            /// <summary>
            /// Gets or sets the Description of the Task
            /// </summary>
            public string Description { get; set; }

            /// <summary>
            /// Gets or sets the Priority of the task
            /// </summary>
            public int Priority { get; set; }
        }

        // *******  Your class called "myQueue" goes here. *******

        /// <summary>
        /// Represents the class for Queue operations
        /// </summary>
        public class MyQueue : PriorityQueue
        {
            /// Initializers...
            Task[] queueItems;
            int _counter;

            /// <summary>
            /// Parameterless constructor
            /// </summary>
            public MyQueue(int _maxSize)
            {
                /// set the defaults...
                _counter = 0;
                queueItems = new Task[_maxSize];
            }


            /// <summary>
            /// Add a task to the Queue.
            /// priority will always be provided as a non-negative integer (zero is valid)
            /// zero (0) is the lowest priority, max priority is only limited by the integer type.
            /// </summary>
            /// <param name="taskDescription">Task</param>
            /// <param name="priority">Priority</param>
            public void AddTask(string taskDescription, int priority)
            {
                if (_counter < 10)
                {
                    /// add the task...
                    queueItems[_counter] = new Task() { Description = taskDescription, Priority = priority };
                    _counter++;

                    /// Queue items sorting
                    /// Priortizes the tasks
                    PrioritizeTasks();
                }
                else
                    Console.WriteLine("Task(s) scheduled are full. Please try again sometime later");
            }

            /// <summary>
            /// "next" task based on the rules above and remove it from the queue.
            /// </summary>
            /// <returns>
            /// "next" task based on the rules above and remove it from the queue.
            /// If the Queue is empty, return null.
            /// </returns>
            public string NextTask()
            {
                if (_counter == 0)
                    return "Queue is empty";

                /// get the item popped 
                Task itemPopped = queueItems[0];

                /// pull up the items               
                PullUpTasks();

                /// decrease the counter
                _counter--;

                /// Queue items sorting
                /// Priortizes the tasks
                //PrioritizeTasks();

                /// "next" task based on the rules above and remove it from the queue
                return itemPopped.Description + " -- " + itemPopped.Priority;
            }

            /// <summary>
            /// Pull Up the tasks
            /// </summary>
            private void PullUpTasks()
            {
                /// loop thru the queue
                for (int item1 = 0; item1 < _counter; item1++)
                {
                    /// loop thru again
                    for (int item2 = item1 + 1; item2 < _counter; item2++)
                    {
                        queueItems[item1] = queueItems[item2];
                        break;
                    }
                }
            }

            /// <summary>
            /// Prioritize the tasks
            /// </summary>
            private void PrioritizeTasks()
            {
                /// loop thru again
                for (int item1 = 0; item1 < _counter; item1++)
                {
                    /// create the temp object
                    Task temp;

                    /// loop thru again
                    for (int item2 = item1 + 1; item2 < _counter; item2++)
                    {
                        /// check the priority and arrange them by descending
                        if (queueItems[item1].Priority < queueItems[item2].Priority)
                        {
                            /// set the item for temp use
                            temp = queueItems[item2];

                            /// push down the items 
                            for (int item3 = item2; item3 > item1; item3--)
                            {
                                queueItems[item3] = queueItems[item3 - 1];
                            }

                            /// set the replaced item
                            queueItems[item1] = temp;
                        }
                    }
                }
            }
        }

        /************************************************************************
        *     Implement your version of the PriorityQueue interface above.      * 
        *************************************************************************/


        /// <summary>
        /// Main function
        /// </summary>
        static void Main(string[] args)
        {
            /// Priority Queue interface
            PriorityQueue pq = null;

            /// Implement the interface above so that "myQueue" is valid.
            pq = new MyQueue(System.Int16.MaxValue);

            /// Check: Tried System.Int16.MaxValue has "Out Of Memory Exception"
         
            //The output for the above should be: 
            /// sixth - 5
            /// third - 3
            /// tenth - 3
            /// eight - 2
            /// ninth - 2
            /// first - 1
            /// second - 1
            /// fourth - 1
            /// fifth - 1
            /// seventh - 1
            
            // Sample test data/code
            pq.AddTask("first", 1);
            pq.AddTask("second", 1);
            pq.AddTask("third", 3);
            pq.AddTask("fourth", 1);
            //Console.WriteLine("GetNext(): " + pq.NextTask());
            //Console.WriteLine("GetNext(): " + pq.NextTask());
            pq.AddTask("fifth", 1);
            pq.AddTask("sixth", 5);
            //Console.WriteLine("GetNext(): " + pq.NextTask());
            //Console.WriteLine("GetNext(): " + pq.NextTask());
            //Console.WriteLine("GetNext(): " + pq.NextTask());
            //Console.WriteLine("GetNext(): " + pq.NextTask());
            //Console.WriteLine("GetNext(): " + pq.NextTask());
            Console.WriteLine("GetNext(): " + pq.NextTask());
            Console.WriteLine("GetNext(): " + pq.NextTask());
            Console.WriteLine("GetNext(): " + pq.NextTask());
            Console.WriteLine("GetNext(): " + pq.NextTask());
            pq.AddTask("seventh", 1);
            pq.AddTask("eighth", 2);
            pq.AddTask("ninth", 2);
            pq.AddTask("tenth", 3);
            Console.WriteLine("GetNext(): " + pq.NextTask());
            Console.WriteLine("GetNext(): " + pq.NextTask());
            Console.WriteLine("GetNext(): " + pq.NextTask());
            Console.WriteLine("GetNext(): " + pq.NextTask());
            Console.WriteLine("GetNext(): " + pq.NextTask());
            Console.WriteLine("GetNext(): " + pq.NextTask());
            Console.WriteLine("GetNext(): " + pq.NextTask());
            Console.WriteLine("GetNext(): " + pq.NextTask());
            Console.WriteLine("GetNext(): " + pq.NextTask());
            Console.WriteLine("GetNext(): " + pq.NextTask());
            Console.ReadLine();

            //The output for the above should be: 
            //GetNext(): third - 3
            //GetNext(): first - 1
            //GetNext(): sixth - 5
            //GetNext(): second - 1
            //GetNext(): fourth - 1
            //GetNext(): fifth - 1
            //GetNext(): 
            //GetNext(): tenth - 3
            //GetNext(): eight - 2
            //GetNext(): ninth - 2
            //GetNext(): seventh - 1
        }
    }
}

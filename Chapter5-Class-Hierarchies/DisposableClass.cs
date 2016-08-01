using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSD_Certification_Toolkit__exam_70_483_.Chapter5_Class_Hierarchies
{
    class DisposableClass : IDisposable
    {
        public string Name { get; set; }
        private bool resourcesAreFreed = false;

        //Free managed and unmanaged resources
        /*
         * A class that implements the IDisposable interface must provide a Dispose method that 
         * cleans up any resources used by the class.
         * 
         * The Dispose method’s main purpose is to clean up unmanaged resources, 
         * but it can also clean up managed resources.
         */
        public void Dispose()
        {
            //execute FreeResources - free managed and unmanaged resources
            FreeResources(true);
        }

        /*
         * The Dispose method frees resources if the program calls it, 
         * but if the program doesn’t call Dispose, the resources are not freed. 
         * 
         * When the GC eventually gets around to destroying the object, 
         * it frees any managed resources, 
         * but unmanaged resources are not freed and are lost to the program. 
         * To handle this situation, 
         * you can give the class a destructor to free resources when the object is destroyed.
         * 
         * A destructor is a method with no return type and a name that includes the class’s name prefixed by ~. 
         * The GC executes an object’s destructor before permanently destroying it.
         */
        //implement the Destructor method
        ~DisposableClass()
        {
            //execute FreeResources - free unmanaged resources only

            FreeResources(false);
        }


        public void FreeResources(bool freeManagedResources)
        {
            Console.WriteLine(Name + ": FreeResources");

            if (!resourcesAreFreed)
            {
                //free up managed resources
                if (freeManagedResources)
                {
                    Console.WriteLine(Name + ": Dispose method Dispose of managed resources");
                }

                Console.WriteLine(Name + ": ~DisposableClass Destructor Dispose of unmanaged resources");

                /*
                 * Set resourcesAreFreed = true so class knows it's resources have been freed.
                 * If the program calls Dispose again later, the method doesn’t do anything, 
                 * so it’s safe to call Dispose more than once.
                 */ 
                resourcesAreFreed = true;

                //tell the Garbace Collector that this object has already been disposed
                //let this object skip the Finalization Queue when it is destroyed
                GC.SuppressFinalize(this);
            }
        }
    }
}

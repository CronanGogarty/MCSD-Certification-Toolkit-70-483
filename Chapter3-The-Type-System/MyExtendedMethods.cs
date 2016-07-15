namespace MCSD_Certification_Toolkit__exam_70_483_
{
    public static class MyExtendedMethods
    {
        /*
         * So, exactly how do you create extension methods? 
         * First, you need to include the extension method in a public static class, so first you must create that class. 
         * After the class is created, you define the method inside that class and make the method an extension method 
         * with the simple addition of the keyword this.
         */
        public static int square(this int num)
        {
            int result = 0;
            result = num * num;
            return result;
        }
    }
}

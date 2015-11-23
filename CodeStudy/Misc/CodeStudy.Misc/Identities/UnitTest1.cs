using System;
using System.Text;
using System.Collections.Generic;
using System.Security.Principal;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeStudy.Misc.Identities
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        public UnitTest1()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestMethod1()
        {
            //
            // TODO: Add test logic here
            //
        }

        [TestMethod]
        public void TestMethodGenericIdentity()
        {
            // Create a GenericIdentity object with no authentication type 
            // specified.
            GenericIdentity defaultIdentity = new GenericIdentity("DefaultUser");

            // Retrieve a GenericIdentity created from current WindowsIdentity
            // values.
            GenericIdentity currentIdentity = GetGenericIdentity();

            ShowIdentityPreferences(new GenericIdentity(""));
            ShowIdentityPreferences(defaultIdentity);
            ShowIdentityPreferences(currentIdentity);

            Console.WriteLine("The sample completed successfully; " +
                "press Enter to continue.");
            Console.ReadLine();
        }

        // Print identity preferences to the console window.
        private static void ShowIdentityPreferences(
            GenericIdentity genericIdentity)
        {
            // Retrieve the name of the generic identity object.
            string identityName = genericIdentity.Name;

            // Retrieve the authentication type of the generic identity object.
            string identityAuthenticationType =
                genericIdentity.AuthenticationType;

            Console.WriteLine("Name: " + identityName);
            Console.WriteLine("Type: " + identityAuthenticationType);

            // Verify that the user's identity has been authenticated
            // (was created with a valid name).
            if (genericIdentity.IsAuthenticated)
            {
                Console.WriteLine("The user's identity has been authenticated.");
            }
            else
            {
                Console.WriteLine("The user's identity has not been " +
                    "authenticated.");
            }
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~");
        }

        // Create generic identity based on values from the current
        // WindowsIdentity.
        private static GenericIdentity GetGenericIdentity()
        {
            // Get values from the current WindowsIdentity.
            WindowsIdentity windowsIdentity = WindowsIdentity.GetCurrent();

            // Construct a GenericIdentity object based on the current Windows
            // identity name and authentication type.
            string userName = windowsIdentity.Name;
            string authenticationType = windowsIdentity.AuthenticationType;
            GenericIdentity authenticatedGenericIdentity =
                new GenericIdentity(userName, authenticationType);

            return authenticatedGenericIdentity;
        }

        [TestMethod]
        public void TestMethodWindowsIdentity()
        {
            // Retrieve the Windows account token for the current user.
            IntPtr logonToken = LogonUser();

            // Constructor implementations.
            IntPtrConstructor(logonToken);
            IntPtrStringConstructor(logonToken);
            IntPtrStringTypeConstructor(logonToken);
            IntPrtStringTypeBoolConstructor(logonToken);

            // Property implementations.
            UseProperties(logonToken);

            // Method implementations.
            GetAnonymousUser();
            ImpersonateIdentity(logonToken);

            Console.WriteLine("This sample completed successfully; " +
                "press Enter to exit.");
            Console.ReadLine();
        }

        // Create a WindowsIdentity object for the user represented by the
        // specified Windows account token.
        private static void IntPtrConstructor(IntPtr logonToken)
        {
            // Construct a WindowsIdentity object using the input account token.
            WindowsIdentity windowsIdentity = new WindowsIdentity(logonToken);

            Console.WriteLine("Created a Windows identity object named " +
                windowsIdentity.Name + ".");
        }


        // Create a WindowsIdentity object for the user represented by the
        // specified account token and authentication type.
        private static void IntPtrStringConstructor(IntPtr logonToken)
        {
            // Construct a WindowsIdentity object using the input account token 
            // and the specified authentication type.
            string authenticationType = "WindowsAuthentication";
            WindowsIdentity windowsIdentity =
                            new WindowsIdentity(logonToken, authenticationType);

            Console.WriteLine("Created a Windows identity object named " +
                windowsIdentity.Name + ".");
        }

        // Create a WindowsIdentity object for the user represented by the
        // specified account token, authentication type, and Windows account
        // type.
        private static void IntPtrStringTypeConstructor(IntPtr logonToken)
        {
            // Construct a WindowsIdentity object using the input account token,
            // and the specified authentication type, and Windows account type.
            string authenticationType = "WindowsAuthentication";
            WindowsAccountType guestAccount = WindowsAccountType.Guest;
            WindowsIdentity windowsIdentity =
                new WindowsIdentity(logonToken, authenticationType, guestAccount);

            Console.WriteLine("Created a Windows identity object named " +
                windowsIdentity.Name + ".");
        }

        // Create a WindowsIdentity object for the user represented by the
        // specified account token, authentication type, Windows account type, and
        // Boolean authentication flag.
        private static void IntPrtStringTypeBoolConstructor(IntPtr logonToken)
        {
            // Construct a WindowsIdentity object using the input account token,
            // and the specified authentication type, Windows account type, and
            // authentication flag.
            string authenticationType = "WindowsAuthentication";
            WindowsAccountType guestAccount = WindowsAccountType.Guest;
            bool isAuthenticated = true;
            WindowsIdentity windowsIdentity = new WindowsIdentity(
                logonToken, authenticationType, guestAccount, isAuthenticated);

            Console.WriteLine("Created a Windows identity object named " +
                windowsIdentity.Name + ".");
        }
        // Access the properties of a WindowsIdentity object.
        private static void UseProperties(IntPtr logonToken)
        {
            WindowsIdentity windowsIdentity = new WindowsIdentity(logonToken);
            string propertyDescription = "The Windows identity named ";

            // Retrieve the Windows logon name from the Windows identity object.
            propertyDescription += windowsIdentity.Name;

            // Verify that the user account is not considered to be an Anonymous
            // account by the system.
            if (!windowsIdentity.IsAnonymous)
            {
                propertyDescription += " is not an Anonymous account";
            }

            // Verify that the user account has been authenticated by Windows.
            if (windowsIdentity.IsAuthenticated)
            {
                propertyDescription += ", is authenticated";
            }

            // Verify that the user account is considered to be a System account
            // by the system.
            if (windowsIdentity.IsSystem)
            {
                propertyDescription += ", is a System account";
            }
            // Verify that the user account is considered to be a Guest account
            // by the system.
            if (windowsIdentity.IsGuest)
            {
                propertyDescription += ", is a Guest account";
            }

            // Retrieve the authentication type for the 
            String authenticationType = windowsIdentity.AuthenticationType;

            // Append the authenication type to the output message.
            if (authenticationType != null)
            {
                propertyDescription += (" and uses " + authenticationType);
                propertyDescription += (" authentication type.");
            }

            Console.WriteLine(propertyDescription);

            // Display the SID for the owner.
            Console.Write("The SID for the owner is : ");
            SecurityIdentifier si = windowsIdentity.Owner;
            Console.WriteLine(si.ToString());
            // Display the SIDs for the groups the current user belongs to.
            Console.WriteLine("Display the SIDs for the groups the current user belongs to.");
            IdentityReferenceCollection irc = windowsIdentity.Groups;
            foreach (IdentityReference ir in irc)
                Console.WriteLine(ir.Value);
            TokenImpersonationLevel token = windowsIdentity.ImpersonationLevel;
            Console.WriteLine("The impersonation level for the current user is : " + token.ToString());
        }

        // Retrieve the account token from the current WindowsIdentity object
        // instead of calling the unmanaged LogonUser method in the advapi32.dll.
        private static IntPtr LogonUser()
        {
            IntPtr accountToken = WindowsIdentity.GetCurrent().Token;
            Console.WriteLine("Token number is: " + accountToken.ToString());

            return accountToken;
        }

        // Get the WindowsIdentity object for an Anonymous user.
        private static void GetAnonymousUser()
        {
            // Retrieve a WindowsIdentity object that represents an anonymous
            // Windows user.
            WindowsIdentity windowsIdentity = WindowsIdentity.GetAnonymous();
        }

        // Impersonate a Windows identity.
        private static void ImpersonateIdentity(IntPtr logonToken)
        {
            // Retrieve the Windows identity using the specified token.
            WindowsIdentity windowsIdentity = new WindowsIdentity(logonToken);

            // Create a WindowsImpersonationContext object by impersonating the
            // Windows identity.
            WindowsImpersonationContext impersonationContext =
                windowsIdentity.Impersonate();

            Console.WriteLine("Name of the identity after impersonation: "
                + WindowsIdentity.GetCurrent().Name + ".");
            Console.WriteLine(windowsIdentity.ImpersonationLevel);
            // Stop impersonating the user.
            impersonationContext.Undo();

            // Check the identity name.
            Console.Write("Name of the identity after performing an Undo on the");
            Console.WriteLine(" impersonation: " +
                WindowsIdentity.GetCurrent().Name);
        }

    }
}

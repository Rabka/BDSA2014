﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Assignment40_1.Tests.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Assignment40_1.Tests.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CategoryID;CategoryName;Description
        ///1;TestBeverages;Test Soft drinks, coffees, teas, beers, and ales
        ///.
        /// </summary>
        internal static string TestCategories {
            get {
                return ResourceManager.GetString("TestCategories", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to OrderID;ProductID;UnitPrice;Quantity;Discount
        ///1;1;100;12;10
        ///2;1;100;10;0
        ///.
        /// </summary>
        internal static string TestOrder_details {
            get {
                return ResourceManager.GetString("TestOrder_details", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to OrderID;CustomerID;EmployeeID;OrderDate;RequiredDate;ShippedDate;ShipVia;Freight;ShipName;ShipAddress;ShipCity;ShipRegion;ShipPostalCode;ShipCountry
        ///1;VINET;5;1996-07-04 00:00:00;1996-08-01 00:00:00;1996-07-16 00:00:00;3;32.38;Vins et alcools Chevalier;59 rue de l&apos;Abbaye;Reims;;51100;TestFrance
        ///2;TOMSP;6;1996-07-05 00:00:00;1996-08-16 00:00:00;1996-07-10 00:00:00;1;11.61;Toms Spezialit„ten;Luisenstr. 48;Mnster;;44087;TestGermany.
        /// </summary>
        internal static string TestOrders {
            get {
                return ResourceManager.GetString("TestOrders", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ProductID;ProductName;SupplierID;CategoryID;QuantityPerUnit;UnitPrice;UnitsInStock;UnitsOnOrder;ReorderLevel;Discontinued
        ///1;TestChai;1;1;10 TestBoxes x 20 TestBags;100;10;0;10;0
        ///.
        /// </summary>
        internal static string TestProducts {
            get {
                return ResourceManager.GetString("TestProducts", resourceCulture);
            }
        }
    }
}
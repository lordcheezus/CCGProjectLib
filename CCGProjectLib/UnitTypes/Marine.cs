﻿using System;
using CCGProjectLib.Enums;
using System.Text;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace CCGProjectLib.UnitTypes
{
    /// <summary>
    /// Marine is a Basic amphibious soldier who is equipped with the ability to excel in amphibious territories or vehicles.
    /// </summary>
    public class Marine : BaseUnitType
    {
        // counter is in place to hold the unique ID for the Marine object.
        // handle is needed to utilize Dispose();
        private static int counter = 0;
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        /// <summary>
        /// Attack property returned range: { 0, 255 }.
        /// </summary>
        public override byte Attack { get { return 1; } set { Attack = 1; } }

        /// <summary>
        /// AttackRange property returned range: {0, 255}.
        /// </summary>
        public override byte AttackRange { get { return 3; } set { Attack = 3; } }

        /// <summary>
        /// Concealment property returned range: {0, 255}.
        /// </summary>
        public override bool Concealed { get { return true; } set { Concealed = true; } }

        /// <summary>
        /// Cover property returned range: {0, 255}.
        /// </summary>
        public override byte Cover { get { return 1; } set { Cover = 1; } }

        /// <summary>
        /// Defense property returned range: { 0, 255 }.
        /// </summary>
        public override byte Defense { get { return 1; } set { Defense = 1; } }

        /// <summary>
        /// Whether or not this unit has been disposed.
        /// </summary>
        public bool Disposed { get; set; } = false;

        /// <summary>
        /// Health property returned range: { 0, 255 }.
        /// </summary>
        public override byte Health { get { return 1; } set { Health = 1; } }

        /// <summary>
        /// Corresponds to the unique counter value for a particular Marine Unit.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// MoveRange property returned range: {0, 255}.
        /// </summary>
        public override byte MoveRange { get { return 2; } set { MoveRange = 2; } }

        /// <summary>
        /// Special property associated with Marine : SpecialStrings.Marine.
        /// </summary>
        public override string Special { get { return UserStrings.SpecialStrings.Marine; } set { Special = UserStrings.SpecialStrings.Marine; } }

        /// <summary>
        /// UnitType enumeration associated with Marine : UnitType.Marine.
        /// </summary>
        public override UnitType UnitType { get { return UnitType.Marine; } set { UnitType = UnitType.Marine; } }

        /// <summary>
        /// Vision property returned range: {0, 255}.
        /// </summary>
        public override byte Vision { get { return 1; } set { Vision = 1; } }

        /// <summary>
        /// Provides a default Marine UnitType object.
        /// </summary>
        public Marine()
        {
            this.Id = System.Threading.Interlocked.Increment(ref counter);
        }

        /// <summary>
        /// ToString override returns this Marine object with all its property values into string format.
        /// </summary>
        /// <returns>A stringly formatted version of this Marine object.</returns>
        public override string ToString()
        {
            if (Disposed)
            {
                return null;
            }

            StringBuilder formattedText = new StringBuilder();

            formattedText.Append($"ID : {Id}\n");
            formattedText.Append($"Attack : {Attack}\n");
            formattedText.Append($"AttackRange : {AttackRange}\n");
            formattedText.Append($"Concealed : {Concealed}\n");
            formattedText.Append($"Covered : {Cover}\n");
            formattedText.Append($"Defense : {Defense}\n");
            formattedText.Append($"Health : {Health}\n");
            formattedText.Append($"Special : {Special}\n");
            formattedText.Append($"UnitType : {UnitType}\n");
            formattedText.Append($"Vision : {Vision}\n");

            return formattedText.ToString();
        }

        /// <summary>
        /// This DisplayString function is for display purposes only for unit tests.
        /// </summary>
        public override void DisplayString()
        {
            Console.WriteLine(this.ToString());
        }

        /// <summary>
        /// Allows the world to dispose of this Marine instance object.
        /// </summary>
        public override void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Manages the state of this Marine object. Sets the Disposed property when the garbage collector finishes its job.
        /// </summary>
        /// <param name="disposing">Logic to perform the disposal process.</param>
        public void Dispose(bool disposing)
        {
            if (Disposed)
            {
                return;
            }

            if (disposing)
            {
                handle.Dispose();
            }

            Disposed = true;
        }
    }
}

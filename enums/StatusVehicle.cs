/*-----------------------------------------------------------------------------------*
 * File Name         : StatusVehicle.cs                                              *
 * Author            : Hugo Lopes                                                    *
 * Creation Date     : 26/10/2024                                                    *
 * Description       : Enumeration defining the status of a vehicle in EMS.          *
 *-----------------------------------------------------------------------------------*/

namespace EMS.enums
{
    /// <summary>
    /// Enumerates the status of vehicle
    /// </summary>
    public enum StatusVehicle
    {
        Disponivel,
        EmServiço,
        EmManutenção,
        Outro
    }
}

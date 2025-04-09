/*-----------------------------------------------------------------------------------*
 * File Name         : StatusEvent.cs                                                *
 * Author            : Hugo Lopes                                                    *
 * Creation Date     : 26/10/2024                                                    *
 * Description       : Enumeration defining the status of an event in EMS.           *
 *-----------------------------------------------------------------------------------*/

namespace EMS.enums
{
    /// <summary>
    /// Enumerates the status of event
    /// </summary>
    public enum StatusEvent
        {
        EmEspera,
        EmProgresso,
        Concluído,
        Outro,
        Pending
    }   

}

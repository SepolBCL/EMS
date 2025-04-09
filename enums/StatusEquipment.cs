/*-----------------------------------------------------------------------------------*
 * Nome do Ficheiro  : StatusEquipment.cs                                            *
 * Autor             : Hugo Lopes                                                    *
 * Data de Criação   : 26/10/2024                                                    *
 * Descrição         : Enumeration defining the status of equipment in EMS.          *
 *-----------------------------------------------------------------------------------*/

namespace EMS.enums
{
    /// <summary>
    /// Enumerates the status of equipement
    /// </summary>
    public enum StatusEquipment
    {
        Disponivel, 
        SemStock,
        EmServiço,
        EmManutenção,       
        Outro
    }
}

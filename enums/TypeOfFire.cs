/*-----------------------------------------------------------------------------------*
 * File Name         : TypeOfFire.cs                                                 *
 * Author            : Hugo Lopes                                                    *
 * Creation Date     : 26/10/2024                                                    *
 * Description       : Enumeration defining different types of fire used in EMS.     *
 *-----------------------------------------------------------------------------------*/

namespace EMS.enums
{
    /// <summary>
    /// Enumerates a type of fire
    /// </summary>
    public enum TypeOfFire
    {
        Classe_A, //Incêndios que envolvem materiais sólidos comuns, como madeira, papel, tecido, borracha e plástico. Estes materiais queimam em superfície e profundidade, deixando resíduos (cinzas e brasas).
        Classe_B, //Incêndios que ocorrem em líquidos inflamáveis ou combustíveis, como gasolina, óleo, graxa, álcool, querosene e solventes. Estes incêndios queimam apenas na superfície e não deixam resíduos.
        Classe_C, //Incêndios que envolvem equipamentos elétricos energizados, como painéis elétricos, fios e aparelhos. É importante notar que o equipamento deve estar ligado à rede elétrica para ser considerado um incêndio de Classe C.
        Classe_D, //Incêndios que envolvem metais combustíveis (também chamados de materiais pirofóricos), como magnésio, titânio, lítio, alumínio fragmentado, zircônio e potássio. Estes incêndios queimam em altas temperaturas.
        Classe_K, //Incêndios que ocorrem em óleos de cozinha e gorduras, comuns em cozinhas industriais e comerciais. Esta classe é específica para incêndios envolvendo equipamentos como fritadeiras, chapas, churrasqueiras e grelhas.
        Outro
    }
}

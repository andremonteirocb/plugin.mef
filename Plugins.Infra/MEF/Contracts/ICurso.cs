using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Phidelis.Plugins.Infra.MEF.Enums.Enumeradores;

namespace Phidelis.Plugins.Infra.MEF.Contracts
{
    public interface ICurso
    {
        int IdCurso { get; set; }
        string Nome { get; set; }
        List<ITurma> Turmas { get; set; }
    }
}

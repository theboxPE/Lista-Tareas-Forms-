using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class ClassNegocio
    {
        ClassDatos objd = new ClassDatos();

        public DataTable N_Listado()
        {
            return objd.D_listado();
        }

        public DataTable N_Busqueda(ClassEntidad obje)
        {
            return objd.D_buscar(obje);
        }

        public String N_Mantenimiento(ClassEntidad obje)
        {
            return objd.D_mantenimiento(obje);
        }
    }
}

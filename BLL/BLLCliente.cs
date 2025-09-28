using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BLL
{
    public class BLLCliente : IClientRegistrationChecker
    {
        DALCliente dalCliente = new DALCliente();
        BLLUsuarioLog log = new BLLUsuarioLog();

        public void Alta(BECliente pCliente)
        {
            
            if (IsClientRegistererd(pCliente.DNI)) 
            {
                MessageBox.Show($"Ya existe un cliente con el DNI : {pCliente.DNI}. ");
            }
            else
            { 
                dalCliente.Alta(pCliente);
                
                BEUsuarioLog beUsuarioLog = new BEUsuarioLog(LoginSession.Instancia.UsuarioActual.IdUsuario, "Alta_Cliente");
                log.Alta(beUsuarioLog);
            }
        }

        public List<BECliente> Listar()
        {
            return dalCliente.Listar();
        }

        public void Baja(BECliente pCliente)
        {
            dalCliente.Baja(pCliente);

            BEUsuarioLog beUsuarioLog = new BEUsuarioLog(LoginSession.Instancia.UsuarioActual.IdUsuario, "Baja_Cliente");
            log.Alta(beUsuarioLog);
        }

        public void Modificar(BECliente pCliente)
        {
            dalCliente.Modificar(pCliente);

            BEUsuarioLog beUsuarioLog = new BEUsuarioLog(LoginSession.Instancia.UsuarioActual.IdUsuario, "Modificacion_Cliente");
            log.Alta(beUsuarioLog);
        }

        public List<BECliente> EncontrarCliente(int DNI)
        {
            return Listar().Where(C => C.DNI == DNI).ToList();

            
        }

        public bool IsClientRegistererd(int pDNI)
        {
            foreach (BECliente cliente in Listar())
            {
                if (cliente.DNI == pDNI)
                    return true;
            }

            return false;
        }
    }
}
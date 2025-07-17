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

        public void Alta(BECliente pCliente)
        {
            
            if (IsClientRegistererd(pCliente.DNI)) 
            {
                MessageBox.Show($"Ya existe un cliente con el DNI : {pCliente.DNI}. ");
            }
            else
            { 
                dalCliente.Alta(pCliente); 
            }
        }

        public List<BECliente> Listar()
        {
            return dalCliente.Listar();
        }

        public void Baja(BECliente pCliente)
        {
            dalCliente.Baja(pCliente);
        }

        public void Modificar(BECliente pCliente)
        {
            dalCliente.Modificar(pCliente);
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
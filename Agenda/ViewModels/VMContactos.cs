using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Xamarin.Forms;

namespace Agenda.ViewModels 
{
    public class VMContactos : INotifyPropertyChanged
    {
        public VMContactos()
        {
            Crear = new Command(() =>
            {
                C.Nombre();
                C.Apellido();
                C.Celular();
                C.Fijo();
                C.Email();
                C = C;

                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Contacto.aut");
                Stream archivo = new FileStream(ruta, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(archivo, C);
                archivo.Close();

            });


            Abrir = new Command(() =>
            {

                BinaryFormatter formatter = new BinaryFormatter();
                string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Contacto.aut");
                Stream archivo = new FileStream(ruta, FileMode.Open, FileAccess.Read, FileShare.None);
                C = (VMContactos)formatter.Deserialize(archivo);
                archivo.Close();

            });

        }

        private void Email()
        {
            throw new NotImplementedException();
        }

        private void Fijo()
        {
            throw new NotImplementedException();
        }

        private void Celular()
        {
            throw new NotImplementedException();
        }

        private void Apellido()
        {
            throw new NotImplementedException();
        }

        private void Nombre()
        {
            throw new NotImplementedException();
        }

        VMContactos c = new VMContactos();
        public VMContactos C
        {
            get => c;
            set
            {

                c = value;
                var args = new PropertyChangedEventArgs(nameof(C));
                PropertyChanged?.Invoke(this, args);

            }
        }

        public Command Crear { get; }
        public Command Abrir { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!Equals(field, newValue))
            {
                field = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }

            return false;
        }

    }
}

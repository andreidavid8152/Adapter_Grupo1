namespace FactoryMethod_Grupo1.Adapter
{
    public class MotorElectricoAdapter : IMotorAdapter
    {
        private readonly MotorElectrico _motorElectrico;

        public MotorElectricoAdapter(MotorElectrico motorElectrico)
        {
            _motorElectrico = motorElectrico;
        }

        public void Iniciar()
        {
            // Aquí adaptas la llamada a los métodos específicos del MotorElectrico
            _motorElectrico.Conectar();
            _motorElectrico.Activar();
        }

        public void Detener()
        {
            // Implementa la lógica para detener el motor eléctrico
            _motorElectrico.Desactivar();
            _motorElectrico.Desconectar();
        }

    }
}


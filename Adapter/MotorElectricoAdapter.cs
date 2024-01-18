namespace Adapter_Grupo1.Adapter
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
            _motorElectrico.Conectar();
            _motorElectrico.Activar();
        }

        public void Detener()
        {
            _motorElectrico.Desactivar();
            _motorElectrico.Desconectar();
        }

    }
}


namespace Adapter_Grupo1.Adapter
{
    public class MotorCombustionAdapter : IMotorAdapter
    {
        private readonly MotorCombustion _motorCombustion;

        public MotorCombustionAdapter(MotorCombustion motorCombustion)
        {
            _motorCombustion = motorCombustion;
        }

        public void Iniciar()
        {
            _motorCombustion.Encender();
            _motorCombustion.Operar();
        }

        public void Detener()
        {
            _motorCombustion.DetenerOperacion();
            _motorCombustion.Apagar();
        }
    }
}

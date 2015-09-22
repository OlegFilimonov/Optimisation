namespace Optimisation.Одномерные.Цепочки
{
    public class svenn_bolz_gr1 : OneDimMethod
    {
        public svenn_bolz_gr1(double eps=1e-6, int maxIterations = 50)
            : base(null,null,eps, "Метод Свенн-Больцано-Фибоначчи2", maxIterations)
        {

        }

        public override void execute()
        {
            OneDimMethod step1, step2;
            step1 = new BolzanoMethod(f,df, eps, 3);
            step2 = new GoldenRatioMethod1(f, eps, 3);
            //ШАГ 1
            setSvenInterval();

            //ШАГ 2
            step1.A = a;
            step1.B = b;
            step1.execute();

            a = step1.A;
            b = step1.B;

            //ШАГ 3
            step2.A = a;
            step2.B = b;
            step2.execute();

            a = step2.A;
            b = step2.B;
            answer = step2.Answer;
        }
    }
}
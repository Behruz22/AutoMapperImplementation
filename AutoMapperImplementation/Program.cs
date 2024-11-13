using System;
using System.Runtime.Intrinsics.Arm;

namespace AutoMapperImplementation
{
    public class Program
    {
        static void Main(string[] args)
        {
            Mapper mapper = new Mapper();
            OneModel oneModel = new OneModel();
            TwoMOdel twoMOdel = new TwoMOdel();

            oneModel.Id = 1;
            oneModel.Name = "test";

            mapper.CreateMap<OneModel, TwoMOdel>(oneModel=>twoMOdel);

            TwoMOdel model=mapper.Map<OneModel,TwoMOdel>(oneModel);

            Console.WriteLine(model.Id);
            Console.WriteLine(model.Name);
            Console.WriteLine(model.Description);

        }
    }
}

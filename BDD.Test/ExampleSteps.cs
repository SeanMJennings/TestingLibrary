namespace BDD.Test;

public partial class ExampleShould
{
    private int sum;
    private ComplexSystem complex_system;
    private int a = 1;
    private int b = 2;
    private int c = 3;
    private int d = 4;
    private int first_number;
    private int second_number;

    protected override Task before_each()
    {
        base.before_each();
        sum = 0;
        first_number = 0;
        second_number = 0;
        complex_system = new ComplexSystem(new MagicDependency());
        return Task.CompletedTask;
    }

    private void two_numbers()
    {
        first_number = a;
        second_number = b;
    }
    
    private Task two_numbers_from_a_remote_source()
    {
        first_number = 0;
        second_number = 2;
        return Task.CompletedTask;
    }

    private static void something_else_we_care_about_setting_up(){}

    private void two_bad_numbers()
    {
        first_number = c;
        second_number = d;
    }

    private void we_give_them_to_our_complex_system()
    {
        sum = complex_system.Sum(first_number, second_number);
    }

    private void giving_them_to_our_complex_system()
    {
        we_give_them_to_our_complex_system();
    }

    private void we_get_the_sum()
    {
        sum = first_number + second_number;
    }    
    
    private Task we_get_the_sum_from_a_remote_source()
    {
        sum = first_number + second_number;
        return Task.CompletedTask;
    }
    
    private static void we_can_validate_something_else(){}
    
    public class ComplexSystem(IAmAMagicDependency magicSystem)
    {
        public int Sum(int a, int b) => magicSystem.PullTheLeverKronk(a, b);
    }

    public interface IAmAMagicDependency
    {
        int PullTheLeverKronk(int a, int b);
    }

    public class MagicDependency : IAmAMagicDependency
    {
        public int PullTheLeverKronk(int a, int b)
        {
            if (a == 3 && b == 4) throw new ArithmeticException("You can't do this!");
            return a + b;
        }
    }
}


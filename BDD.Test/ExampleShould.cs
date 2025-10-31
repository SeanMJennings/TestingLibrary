namespace BDD.Test;

[TestFixture]
public partial class ExampleShould : Specification
{
    [Test]
    public void pass_our_first_behavioural_test()
    {
        Given(two_numbers);
        When(we_give_them_to_our_complex_system);
        Then(we_get_the_sum);
        And(we_can_validate_something_else);
    }

    [Test]
    public void catch_a_prohibited_action()
    {
        Given(two_bad_numbers);
        And(something_else_we_care_about_setting_up);
        When(Validating(giving_them_to_our_complex_system));
        Then(Informs("You can't do this!"));
    }
    
    [Test]
    public async Task pass_our_first_behavioural_test_async()
    {
        await Given(two_numbers_from_a_remote_source);
              When(we_give_them_to_our_complex_system);
        await Then(we_get_the_sum_from_a_remote_source);
              And(we_can_validate_something_else);
    }
}
using Csla.Core;
using Csla.Rules;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RFit.BusinessLibrary.Rules
{
    public class ResourceNoDuplicateFirstNameAndLastNameRule : Csla.Rules.BusinessRuleAsync
    {
        private IPropertyInfo LastNameProperty { get; set; }
        private IPropertyInfo IdProperty { get; set; }

        public ResourceNoDuplicateFirstNameAndLastNameRule(
            IPropertyInfo primaryProperty, IPropertyInfo lastNameProperty, IPropertyInfo idProperty) : base(primaryProperty)
        {

            LastNameProperty = lastNameProperty;
            IdProperty = idProperty;
            InputProperties.Add(PrimaryProperty);
            InputProperties.Add(LastNameProperty);
            InputProperties.Add(IdProperty);
        }

        protected override async Task ExecuteAsync(IRuleContext context)
        {
            var firstName = (string)context.InputPropertyValues[PrimaryProperty];
            var lastName = (string)context.InputPropertyValues[LastNameProperty];
            var id = (int)context.InputPropertyValues[IdProperty];

            // Est ce que le nom existe déjà ?
            var result = await ResourceExistsByFirstNameAndLastNameCommand.ExecuteAsync(firstName, lastName);
            if (result > 0 && result != id)
            {
                context.AddErrorResult("Duplication !");
                return;
            }
        }
    }
}

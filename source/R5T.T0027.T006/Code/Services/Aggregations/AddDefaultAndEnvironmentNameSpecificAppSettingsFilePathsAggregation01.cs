using System;
using R5T.Dacia;

using R5T.T0027.Configuration.T001;

using R5T.T0027.A002;


namespace R5T.T0027.T006
{
    public class AddDefaultAndEnvironmentNameSpecificAppSettingsFilePathsAggregation01
    {
        public AppSettingsServicesAggregation01 AppSettingsServices { get; set; }
        public IServiceAction<AddDefaultAndEnvironmentNameSpecificAppSettingsFilePaths> AddDefaultAndEnvironmentNameSpecificAppSettingsFilePathsAction { get; set; }
    }
}

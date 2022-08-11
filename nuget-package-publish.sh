#!/bin/bash

#----------- Variables -----------
nuget_key="[NUGET_KEY]"
nuget_website="https://www.nuget.org/packages/Plugin.MaterialDesignControls/"
solution_path="src/MaterialDesignControls.sln"
ios_project_path="src/MaterialDesignControls.iOS/MaterialDesignControls.iOS.csproj"
android_project_path="src/MaterialDesignControls.Android/MaterialDesignControls.Android.csproj"
nuspect_file_path="MaterialDesignControls.nuspec"
nupkg_file_name="Plugin.MaterialDesignControls"

#----------- Functions -----------
function restore_packages()
{
    echo "> Executing clean solution..."
    msbuild $solution_path -t:restore,build -p:RestorePackagesConfig=true
    echo "> Clean solution executed!"
}

function build_projects()
{
    echo "> Executing build iOS project..."
    msbuild $ios_project_path -t:Rebuild -p:Configuration=Release
    echo "> Build iOS project executed!"

    echo "> Executing build Android project..."
    msbuild $android_project_path -t:Rebuild -p:Configuration=Release
    echo "> Build Android project executed!"
}

function get_nuget_version()
{
    echo "> Executing get nuget version..."
    filename=$1
    while read line; do
        if [[ $line == *"<version>"* ]];
        then
            result=$line
            result=${result//[\/]}
            result=${result//"<version>"}
            nuget_version=$result
            echo $nuget_version
        fi
    done < $filename
    echo "> Get nuget version executed!"
}

function nuget_pack_push()
{
    echo "> Executing nuget pack..."
    nuget pack
    echo "> Nuget pack executed!"

    echo "> Executing nuget push..."
    nuget push $1 $2 -Source https://api.nuget.org/v3/index.json
    echo "> Nuget push executed!"

    #GET THE NUGET VERSION FROM THE nupkg FILE
}

function remove_nupkg_files()
{
    echo "> Executing remove nupkg files..."
    rm *.nupkg
    echo "> Remove nupkg files executed!"
}

function open_nuget_website()
{
    echo "> Executing open nuget website ($1)..."
    open $1
    echo "> Open nuget website executed!"
}

#----------- Main -----------
if [ "$nuget_key" == "[NUGET_KEY]" ]; then
    echo "Nuget package publish was canceled, you have to set nuget_key variable!!!"
else
    restore_packages
    build_projects
    get_nuget_version $nuspect_file_path
    nuget_pack_push "$nupkg_file_name.$nuget_version.nupkg" $nuget_key
    remove_nupkg_files
    open_nuget_website $nuget_website
fi

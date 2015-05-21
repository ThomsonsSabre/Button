#!/bin/sh
 
# Helper
safeRunCommand() {
    typeset cmd="$*"
    typeset ret_code
 
    echo cmd=$cmd
    eval $cmd
    ret_code=$?
    if [ $ret_code != 0 ]; then
        printf "Error : [%d] when executing command: '$cmd'" $ret_code
        exit $ret_code
    fi
}
 
# Path To MSBuild.exe
MSBuild="/c/Windows/Microsoft.NET/Framework/v4.0.30319/MSBuild.exe"
# Path To MSTest.exe
MSTest="/d/Program\ Files\ \(x86\)/Microsoft\ Visual\ Studio\ 12.0/Common7/IDE/MSTest.exe"
# Get Project root path (without tailing /)
ProjectRoot="$(git rev-parse --show-toplevel)"
 
# Test Containers (without leading /)
Tests=(
    "SabreSwitch.Tests/bin/Debug/SabreSwitch.Tests.dll"
)
 
 
# Build
safeRunCommand $MSBuild $ProjectRoot/SabreSwitch.sln
 
# Test
Args=("${Tests[@]/#//testcontainer:$ProjectRoot/}")
safeRunCommand $MSTest $(eval 'echo "${Args[*]}"')

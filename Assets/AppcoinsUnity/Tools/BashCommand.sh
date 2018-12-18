#!/bin/sh
osascript -e 'activate application "/Applications/Utilities/Terminal.app"'
cd '/Users/brunovarela/Documents/sprint_20_11_4_12/Red Runner'
if [ "$('/Users/brunovarela/Library/Android/sdk/platform-tools/adb' get-state)" == "device" ]
then
'/Users/brunovarela/Library/Android/sdk/platform-tools/adb' shell am start -n 'com.appcoins.redrunner/.UnityPlayerActivity' 2>&1 2>'/Users/brunovarela/Documents/GitHub/RedRunner/Assets/AppcoinsUnity/Tools/ProcessError.out'
else
echo error: no usb device found > '/Users/brunovarela/Documents/GitHub/RedRunner/Assets/AppcoinsUnity/Tools/ProcessError.out'
fi
echo 'done' > '/Users/brunovarela/Documents/GitHub/RedRunner/Assets/AppcoinsUnity/Tools/ProcessCompleted.out'
exit

# MyMilightRemote
A replacement for the Milight v1.1 app for the WifiBridge V2 (which doesnt work with newer android versions anymore)

# How to use lombok with newer Android Studio Versions:


Since Android Studio officially dropped Lombok Support, you will need to manually install Lombok by yourself for each Android Studio update.

<b>We've provided the zipped plugin for you already under /lombok subfolder.</b>
If the build for your android version is not there, you can follow the steps below to generate your own compatible lombok.

1. Download [The latest release (0.34.1-2019.1)](https://plugins.jetbrains.com/plugin/6317-lombok/versions).
2. Extract lib\lombok-plugin-0.34.1-2019.1.jar
3. Extract META-INF\plugin.xml.
4. Open META-INF\plugin.xml with a text editor and replace 
   <idea-version since-build="191.6183" until-build="191.*"/>
   with <idea-version since-build="191.6183" until-build="YOUR_ANDROID_STUDIO_VERSION.*"/>
   you can find YOUR_ANDROID_STUDIO_VERSION under Help→About in Android Studio. I.E. Build #AI-222.4459.24.2221.9862592 becomes <idea-version since-build="191.6183" until-build="222.*"/>
5. Save the file
6. Execute `jar uf lombok-plugin-0.34.1-2019.1.jar META-INF/plugin.xml`
7. Manually install lombok via "Install Plugin From Disk" in Android Studio
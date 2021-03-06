# FluentMobileElement Constructor (AppiumTestObject, By, String)
 

Initializes a new instance of the FluentElement class

**Namespace:**&nbsp;<a href="#/MAQS_4/Appium_AUTOGENERATED/Magenic-MaqsFramework-BaseAppiumTest_Namespace">Magenic.MaqsFramework.BaseAppiumTest</a><br />**Assembly:**&nbsp;Magenic.MaqsFramework.BaseAppiumTest (in Magenic.MaqsFramework.BaseAppiumTest.dll) Version: 4.0.4.0 (4.0.4)

## Syntax

**C#**<br />
``` C#
public FluentMobileElement(
	AppiumTestObject testObject,
	By locator,
	string userFriendlyName
)
```


#### Parameters
&nbsp;<dl><dt>testObject</dt><dd>Type: <a href="#/MAQS_4/Appium_AUTOGENERATED/AppiumTestObject_Class">Magenic.MaqsFramework.BaseAppiumTest.AppiumTestObject</a><br />The base Selenium test object</dd><dt>locator</dt><dd>Type: By<br />The 'by' selector for the element</dd><dt>userFriendlyName</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />A user friendly name, for logging purposes</dd></dl>

## Examples

**C#**<br />
``` C#
private FluentElement DisabledItem
{
    get { return new FluentElement(this.TestObject, By.CssSelector("#disabledField INPUT"), "Disabled"); }
}
```


## See Also


#### Reference
<a href="#/MAQS_4/Appium_AUTOGENERATED/FluentMobileElement_Class">FluentMobileElement Class</a><br /><a href="#/MAQS_4/Appium_AUTOGENERATED/FluentMobileElement_Constructor">FluentMobileElement Overload</a><br /><a href="#/MAQS_4/Appium_AUTOGENERATED/Magenic-MaqsFramework-BaseAppiumTest_Namespace">Magenic.MaqsFramework.BaseAppiumTest Namespace</a><br />
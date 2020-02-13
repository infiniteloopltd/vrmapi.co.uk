# vrmapi.co.uk
UK VRM lookup based on https://www.RegCheck.org.uk API

The only file missing is the web.config, which contains your RegCheck username, and recaptcha secret key

```xml
<?xml version="1.0"?>
<configuration>
  <appSettings>
    <add key="REGCHECK_USERNAME" value="xxxxx"/>
    <add key="SECRET_KEY" value="xxxxxx"/>
  </appSettings>
  <system.web>
    <compilation debug="true" targetFramework="4.0"/>
  </system.web>
  <system.serviceModel>
    <bindings>
      <basicHttpBinding>
        <binding name="BespokeAPISoap"/>
      </basicHttpBinding>
      <customBinding>
        <binding name="BespokeAPISoap12">
          <textMessageEncoding messageVersion="Soap12"/>
          <httpTransport/>
        </binding>
      </customBinding>
    </bindings>
    <client>
      <endpoint address="http://www.regcheck.org.uk/api/bespokeapi.asmx" binding="basicHttpBinding" bindingConfiguration="BespokeAPISoap" contract="regcheck.BespokeAPISoap" name="BespokeAPISoap"/>
    
    </client>
  </system.serviceModel>
</configuration>
```

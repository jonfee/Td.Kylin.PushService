@echo.��������......  
@echo off  
@sc create KylinPushService binPath= "D:\Work\01-Projects\KylinPushService\KylinPushService\bin\Debug\KylinPushService.exe"  
@net start KylinPushService  
@sc description KylinPushService "Kylin��Ϣ���ͷ���"
@sc config KylinPushService start= AUTO  
@echo off  
@echo.������ϣ�  
@pause  
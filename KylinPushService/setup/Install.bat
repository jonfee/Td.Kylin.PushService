@echo.��������......  
@echo off  
@sc create KylinPushService binPath= "F:\20151120Git\Td.Kylin.PushService\KylinPushService\bin\Debug\KylinPushService.exe"  
@net start KylinPushService  
@sc description KylinPushService "Kylin��Ϣ���ͷ���"
@sc config KylinPushService start= AUTO  
@echo off  
@echo.������ϣ�  
@pause  
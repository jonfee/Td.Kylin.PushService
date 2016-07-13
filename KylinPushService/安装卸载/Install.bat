@echo.服务启动......  
@echo off  
@sc create KylinPushService binPath= "F:\20151120Git\Td.Kylin.PushService\KylinPushService\bin\Debug\KylinPushService.exe"  
@net start KylinPushService  
@sc description KylinPushService "Kylin消息推送服务"
@sc config KylinPushService start= AUTO  
@echo off  
@echo.启动完毕！  
@pause  
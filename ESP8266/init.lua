--wifi.setmode(wifi.STATION)
--wifi.sta.config("NETWORK_NAME","NETWORK_PASSWORD")

local led = 4
gpio.mode(led, gpio.OUTPUT)
local duration = 2000
collectgarbage()

function check_server()
    tmr.wdclr()
    if pcall(get_data) then print ("OK")
    else print ("ERROR")
    end
end
    
function get_data() 
    http = require("http")
    http.get("178.62.195.200", 80, "/remote_light/light_service.php",{x="x"}, function(payload)  
        --print(payload)  
        if payload == "OK" then gpio.write(led, gpio.HIGH) end
        if payload == "NOTOK" then gpio.write(led, gpio.LOW) end
        end)
    http = nil
    package.loaded["http"]=nil
    collectgarbage()
end

tmr.alarm(0, duration, 1, get_data)
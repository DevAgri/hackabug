// ###########################
// ## Bibliotecas auxiliares #
// ###########################
#include <OneWire.h>
#include <DallasTemperature.h>
#include "DHT.h"
#include <SPI.h>
#include <Ethernet.h>
#include <Wire.h>
#define ONE_WIRE_BUS 2
#define SoilHumiditySensor A0
#define IsRainingSensor A1
#define DhtPin 3
#define DEBUG 0

// ##############################
// # Vari�veis de escopo global #
// ##############################
String readString;
double totalSoil;
double totalSTemp;
double totalUm;
double soilTempAvrg;
double maxSoilTemp = 0;
double minSoilTemp = 9999999999;
double maxTemp = 0;
double minTemp = 99999999999;
double maxAirHumidity = 0;
double minAirHumidity = 99999999999;
double airHumidityAvrg;
double tempAvrg;
EthernetServer server(80);
enum SoilHumidityLevel
{
	LOWER,
	MEDIUM,
	HIGHER
};
DHT dht;
unsigned long ul_CurrentMillis;
unsigned long ul_PreviousMillis;
unsigned long updateInterval = 30000;
int counter = 0;
OneWire oneWire(ONE_WIRE_BUS);
DallasTemperature soilSensors(&oneWire);
IPAddress deviceIp(10, 1, 1, 10);
byte deviceMac[] = { 0xFF, 0x91, 0xBA, 0xFE, 0xFE, 0xF0 };
EthernetClient ethClient;
// ######################
// # Fun��es Auxiliares #
// ######################
SoilHumidityLevel getSoilHumidityLevel();
boolean isRaining();
void setup()
{
  Ethernet.begin(deviceMac, deviceIp);
  Serial.begin(9600);
  soilSensors.begin();
  dht.setup(DhtPin);
  Serial.println(Ethernet.localIP());
}

void loop() {
  EthernetClient client = server.available();
	ul_CurrentMillis = millis();
	float humidity = dht.getHumidity();
	float temperature = dht.getTemperature();
	soilSensors.requestTemperatures();
	float soilTemp = soilSensors.getTempCByIndex(0);
	SoilHumidityLevel soilhum = getSoilHumidityLevel();
	maxAirHumidity = max(humidity, maxAirHumidity);
	minAirHumidity = min(humidity, minAirHumidity);
	maxTemp = max(temperature, maxTemp);
	minTemp = min(temperature, minTemp);
	maxSoilTemp = max(soilTemp, maxSoilTemp);
	minSoilTemp = min(soilTemp, minSoilTemp);
	totalSoil = totalSoil + soilTemp;
	totalUm = totalUm + humidity;
	totalSTemp = totalSTemp + temperature;
	counter++;
  if (client.available()) {
        char c = client.read();
 
        if (readString.length() < 100) {
          readString += c;             
        }
        if (c == '\n') {
           client.println("HTTP/1.1 200 OK");
           client.println("Content-Type: application/json;charset=utf-8"); 
           client.println("Server: Arduino");
           client.println("Connnection: close");
           client.println();
           client.print("{\"Umidade\":");
           client.print(humidity);
           client.print(", \"MaxTemp\":");
           client.print(maxTemp);
           client.print(", \"Temperatura\":");
           client.print(temperature);
           client.print(", \"MinTemp\":");
           client.print(minTemp);     
           client.print(", \"MaxAirHumidity\":");
           client.print(maxAirHumidity);
           client.print(", \"minAirHumidity\":");
           client.print(minAirHumidity);
           client.print(", \"maxSoilTemp\":");
           client.print(maxSoilTemp);
           client.print(", \"minSoilTemp\":");
           client.print(minSoilTemp); 
           client.print(", \"isRaining\":");
           client.print(isRaining());
           client.print(", \"soilTempAvrg\":");
           client.print(soilTempAvrg);
           client.print(", \"airHumidityAvrg\":");
           client.print(airHumidityAvrg);
           client.print(", \"tempAvrg\":");
           client.print(tempAvrg);
           client.print("}");
          client.stop();
          readString=""; 
        }
       }
       
	if (ul_CurrentMillis - ul_PreviousMillis > updateInterval
			|| ul_CurrentMillis - ul_PreviousMillis < 0) {
			ul_PreviousMillis = ul_CurrentMillis;
			soilTempAvrg = totalSoil / counter;
			airHumidityAvrg = totalUm / counter;
			tempAvrg = totalSTemp / counter;
      totalSoil = 0;
      totalUm = 0;
      totalSTemp = 0;
			maxSoilTemp = 0;
			minSoilTemp = 9999999999;
			maxTemp = 0;
			minTemp = 99999999999;
			maxAirHumidity = 0;
			minAirHumidity = 99999999999;
			counter = 0;
   }
  #if DEBUG
		Serial.println("Chovendo?");
		Serial.println(isRaining());
    Serial.println("Umidade do solo");
    Serial.println(soilhum);
    if (counter == 0) {
      Serial.println("Temperatura media do solo");
      Serial.println(soilTempAvrg);
      Serial.println("Umidade media do ar");
      Serial.println(airHumidityAvrg);
      Serial.println("Temperatura media");
      Serial.println(tempAvrg);
    }
    Serial.println("Temperatura max do solo");
		Serial.println(maxSoilTemp);
    Serial.println("Temperatura min do solo");
		Serial.println(minSoilTemp);
    Serial.println("Temperatura max");
		Serial.println(maxTemp);
    Serial.println("Temperatura min");
		Serial.println(minTemp);
    Serial.println("Umidade maxima do ar");
		Serial.println(maxAirHumidity);
    Serial.println("umidade minima ar");
		Serial.println(minAirHumidity);
    Serial.println("counter");
		Serial.println(counter);
	#endif // DEBUG 
}

// ######################
// # Fun��es Auxiliares #
// ######################

SoilHumidityLevel getSoilHumidityLevel() {
	int readed = analogRead(SoilHumiditySensor);
	if (readed <= 340) return HIGHER;
	if (readed >= 341 && readed <= 642) return MEDIUM;
	return LOWER;
}

boolean isRaining() {
  if (analogRead(IsRainingSensor) <= 700) return true;
  return false;
}

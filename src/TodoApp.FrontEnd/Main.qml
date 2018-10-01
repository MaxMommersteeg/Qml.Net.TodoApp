import QtQuick 2.11
import QtQuick.Controls 2.4
import QtQuick.Controls.Material 2.4
import QtQuick.Layouts 1.3
import QtBluetooth 5.2

import "Pages"

ApplicationWindow {
    id: window
    width: 800
    height: 600
    visible: true
    title: "Todo App"

    Material.theme: Material.Light
    Material.primary: '#1E88E5'
    Material.accent: Material.Green

    GridLayout {
        anchors.fill: parent
        anchors.margins: 0
        rowSpacing: 10
        columnSpacing: 10
        flow:  width > height ? GridLayout.LeftToRight : GridLayout.TopToBottom
                
        Rectangle {
            Layout.fillWidth: true
            Layout.fillHeight: true
            
            TodoItemPage { }
        }
    }

	Item {
		id: top

		property BluetoothService currentService

		BluetoothDiscoveryModel {
			id: btModel
			running: true
			discoveryMode: BluetoothDiscoveryModel.DeviceDiscovery
			onDiscoveryModeChanged: console.log("Discovery mode: " + discoveryMode)
			onServiceDiscovered: console.log("Found new service " + service.deviceAddress + " " + service.deviceName + " " + service.serviceName);
			onDeviceDiscovered: console.log("New device: " + device)
			onErrorChanged: {
					switch (btModel.error) {
					case BluetoothDiscoveryModel.PoweredOffError:
						console.log("Error: Bluetooth device not turned on"); break;
					case BluetoothDiscoveryModel.InputOutputError:
						console.log("Error: Bluetooth I/O Error"); break;
					case BluetoothDiscoveryModel.InvalidBluetoothAdapterError:
						console.log("Error: Invalid Bluetooth Adapter Error"); break;
					case BluetoothDiscoveryModel.NoError:
						break;
					default:
						console.log("Error: Unknown Error"); break;
					}
			}
	   }
	}
}
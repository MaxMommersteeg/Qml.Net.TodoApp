import QtQuick 2.12
import QtQuick.Controls 2.12
import QtQuick.Controls.Material 2.12
import QtQuick.Layouts 1.12

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
}

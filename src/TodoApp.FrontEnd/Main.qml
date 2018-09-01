import QtQuick 2.11
import QtQuick.Controls 2.4
import QtQuick.Controls.Material 2.4
import QtQuick.Layouts 1.3

import "Pages"

ApplicationWindow {
        width: 800
        height: 600
        visible: true
        title: "Todo App"

        font.family: "Roboto"
        Material.theme: Material.Light
        Material.accent: '#0D47A1'
        Material.primary: '#1E88E5'

        GridLayout {
                anchors.fill: parent
                anchors.margins: 0
                rowSpacing: 25
                columnSpacing: 20
                flow:  width > height ? GridLayout.LeftToRight : GridLayout.TopToBottom
                
                Rectangle {
                    Layout.fillWidth: true
                    Layout.fillHeight: true
            
                    TodoItemList {}
                }
    }
}
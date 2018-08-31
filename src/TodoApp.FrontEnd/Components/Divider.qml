import QtQuick 2.6

Column {
        width: parent.width
        property alias label: textLabel.text

        Rectangle {
                border.width: 1
                height: 1
                width: parent.width
                border.color: "#bababa"
                radius: 10
        }
        Text {
                id: textLabel
                width: parent.width
                horizontalAlignment: Text.AlignHCenter
                font.bold: true
        }
}
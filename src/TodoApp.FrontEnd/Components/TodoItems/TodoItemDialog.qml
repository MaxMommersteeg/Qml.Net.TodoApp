import QtQuick 2.9
import QtQuick.Controls 2.3
import QtQuick.Controls.Material 2.1

Dialog {
        id: root

        modal: true
        focus: true
        title: todoItemTitle
        x: (window.width - width) / 2
        y: 0
        width: Math.min(window.width, window.height) / 3 * 2

        Label {
                width: root.availableWidth
                text: todoItemDescription
                wrapMode: Label.Wrap
                font.pixelSize: 14
                color: '#777777'
        }
}
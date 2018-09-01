import QtQuick 2.6
import QtQuick.Controls 2.1
import QtQuick.Controls.Material 2.1

Button {
        id: materialButton
        signal clicked();

        MouseArea {
            hoverEnabled: true
            anchors.fill: parent
            onEntered: { cursorShape = Qt.PointingHandCursor }
            onExited: { cursorShape = Qt.ArrowCursor }
            onClicked: materialButton.clicked()
        }
}
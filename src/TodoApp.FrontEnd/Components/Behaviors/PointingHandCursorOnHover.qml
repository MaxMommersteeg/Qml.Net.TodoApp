import QtQuick 2.12

MouseArea {
    hoverEnabled: true
    anchors.fill: parent
    cursorShape: containsMouse ? Qt.PointingHandCursor : Qt.ArrowCursor
}

import QtQuick 2.11

MouseArea {
    hoverEnabled: true
    anchors.fill: parent
    cursorShape: containsMouse ? Qt.PointingHandCursor : Qt.ArrowCursor
}
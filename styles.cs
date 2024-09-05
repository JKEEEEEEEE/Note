/* Общие стили */
body {
    font-family: 'Roboto', sans-serif;
    margin: 0;
    padding: 0;
    background-color: #f5f5f5;
    color: #333;
}

.container {
    display: flex;
    flex-direction: column;
    height: 100vh;
    max-width: 1200px;
    margin: auto;
    border-radius: 8px;
    overflow: hidden;
    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
}

header {
    background-color: #4a90e2;
    color: #fff;
    padding: 1rem;
    text-align: center;
    font-size: 1.5rem;
}

.content {
    display: flex;
    flex: 1;
    overflow: hidden;
}

.sidebar {
    background-color: #fff;
    width: 300px;
    padding: 1rem;
    box-shadow: 2px 0 5px rgba(0, 0, 0, 0.1);
    border-right: 1px solid #ddd;
}

.notes-list {
    list-style: none;
    padding: 0;
    margin: 0;
}

.note-item {
    padding: 0.75rem;
    cursor: pointer;
    border-radius: 4px;
    transition: background-color 0.3s, transform 0.3s;
    margin-bottom: 0.5rem;
    background-color: #f9f9f9;
}

.note-item:hover {
    background-color: #e1e1e1;
    transform: scale(1.02);
}

.note-item:active {
    background-color: #d1d1d1;
}

.note-body {
    flex: 1;
    padding: 1rem;
    background-color: #fff;
}

.note-content {
    border: 1px solid #ddd;
    padding: 1.25rem;
    border-radius: 8px;
    background-color: #fafafa;
    box-shadow: inset 0 1px 3px rgba(0, 0, 0, 0.1);
}

/* Адаптивность */
@media (max-width: 768px) {
    .container {
        flex-direction: column;
        height: auto;
    }

    .sidebar {
        width: 100%;
        border-right: none;
        border-bottom: 1px solid #ddd;
    }

    .note-body {
        padding: 0.5rem;
    }
}

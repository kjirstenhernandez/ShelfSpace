namespace ShelfSpace;

public class UserState {
    public ShelfSpace.Models.User user { get; private set; } = new();

    public void RemoveMediaItem(MediaItem item) {
        user.MediaShelf.Remove(item);
    }
}
public interface IImageLoader {
    Bitmap LoadImage(string path);
}

public class FileImageLoader : IImageLoader {
    public Bitmap LoadImage(string path) {
        // Code to load image from file
    }
}

public class DatabaseImageLoader : IImageLoader {
    public Bitmap LoadImage(string path) {
        // Code to load image from database
    }
}

public class ImageProcessor {
    private readonly IImageLoader _imageLoader;

    public ImageProcessor(IImageLoader imageLoader) {
        _imageLoader = imageLoader;
    }

    public Bitmap ProcessImage(string path) {
        Bitmap image = _imageLoader.LoadImage(path);

        // Code to process image

        return processedImage;
    }
}

/*
ImageProcessor đang sử dụng một đối tượng IImageLoader thông qua constructor. 
Các đối tượng FileImageLoader và DatabaseImageLoader đều triển khai interface IImageLoader 
và có thể được sử dụng để tải hình ảnh. 
Có thể dễ dàng thay đổi đối tượng IImageLoader được sử dụng trong ImageProcessor mà không phải sửa đổi mã của ImageProcessor.
*/